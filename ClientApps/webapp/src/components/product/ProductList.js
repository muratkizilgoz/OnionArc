import React, { Fragment, useContext, useEffect, useState } from "react";
import { AppContext } from "../../context/app-context";
import Card from "../ui/Card";
import classes from "./ProductList.module.css";

const ProductList = ({ isCrud, setFormInput, removeHandler }) => {
  const appContext = useContext(AppContext);
  const [categoryFilter, setCategoryFilter] = useState();
  const [orderFilter, setOrderFilter] = useState();

  useEffect(() => {
    const getFilterProducts = async () => {
      const data = {
        categoryId: categoryFilter,
        order: orderFilter,
      };

      const response = await fetch(
        `${process.env.REACT_APP_API_URL}/Product/Filter`,
        {
          method: "post",
          mode: "cors",
          headers: {
            Accept: "application/json, text/plain",
            "Content-Type": "application/json;charset=UTF-8",
          },
          body: JSON.stringify(data),
        }
      );
      if (response.ok) {
        const responseData = await response.json();
        appContext.setProductList(responseData);
      }
    };
    if (categoryFilter || orderFilter) getFilterProducts();
  }, [categoryFilter, orderFilter]);

  const productList = appContext.productList.map((x) => {
    return (
      <div className={classes.product} key={x.id}>
        <div
          onClick={() => {
            isCrud &&
              setFormInput(appContext.productList.find((y) => y.id === x.id));
          }}
        >
          <Card>
            <ul>
              <li>Name: {x.name}</li>
              <li>Description: {x.description}</li>
              <li>Quantity: {x.quantity}</li>
              <li>Price: {x.price.toFixed(2)}</li>
              <li>Category: {x.categoryName}</li>
            </ul>
          </Card>
        </div>
        {isCrud && (
          <div style={{ display: "flex", flex: 1, justifyContent: "center" }}>
            <button
              type="submit"
              style={{
                padding: ".5rem 1rem",
                backgroundColor: "red",
                color: "white",
                fontWeight: "bold",
                margin: ".5rem",
              }}
              onClick={() =>
                removeHandler(appContext.productList.find((y) => y.id === x.id))
              }
            >
              Remove
            </button>
          </div>
        )}
      </div>
    );
  });

  return (
    <Fragment>
      <section>
        {!isCrud && (
          <div className={classes.filter}>
            <div>
              <label>Category:</label>
              <select
                value={categoryFilter && categoryFilter}
                onChange={(event) => setCategoryFilter(event.target.value)}
              >
                <option value="">Select Category</option>
                {appContext.categoryList.map((x) => (
                  <option key={x.id} value={x.id}>
                    {x.name}
                  </option>
                ))}
              </select>
            </div>
            <div>
              <label>Sort By:</label>
              <select
                value={orderFilter && orderFilter}
                onChange={(event) => setOrderFilter(event.target.value)}
              >
                <option value="">Select Option</option>
                <option value="1">Price Low to High</option>
                <option value="2">Price High to Low</option>
              </select>
            </div>
          </div>
        )}

        {productList}
      </section>
    </Fragment>
  );
};

export default ProductList;
