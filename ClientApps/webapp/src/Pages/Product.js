import React, { Fragment, useContext, useState } from "react";
import ProductForm from "../components/product/ProductForm";
import ProductList from "../components/product/ProductList";
import { AppContext } from "../context/app-context";

const Product = () => {
  const [formInput, setFormInput] = useState({
    id: "",
    name: "",
    description: "",
    quantity: "",
    price: "",
    categoryId: "",
  });

  const submitHandler = (event) => {
    event.preventDefault();
    let patch = "ADD";
    if (formInput.id.length !== 0) {
      patch = "UPDATE";
    }
    appContext.crudProduct(formInput, patch);
    setFormInput({
      id: "",
      name: "",
      description: "",
      quantity: "",
      price: "",
      categoryId: "",
    });
  };

  const removeHandler = (product) => {
    appContext.crudProduct(product, "DELETE");
    setFormInput({
      id: "",
      name: "",
      description: "",
      quantity: "",
      price: "",
      categoryId: "",
    });
  };

  const appContext = useContext(AppContext);
  return (
    <Fragment>
      <h3>Product</h3>
      <div style={{ display: "flex", flex: "1" }}>
        <div style={{ display: "flex", flexDirection: "column", flex: "1" }}>
          <ProductList
            isCrud={true}
            setFormInput={setFormInput}
            removeHandler={removeHandler}
          />
        </div>
        <div style={{ display: "flex", flex: "1" }}>
          <ProductForm
            formInput={formInput}
            setFormInput={setFormInput}
            submitHandler={submitHandler}
          />
        </div>
      </div>
    </Fragment>
  );
};

export default Product;
