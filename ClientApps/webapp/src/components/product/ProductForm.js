import React, { Fragment, useContext } from "react";
import { AppContext } from "../../context/app-context";
import Input from "../ui/Input";
import classes from "./ProductForm.module.css";

const ProductForm = ({ formInput, setFormInput, submitHandler }) => {
  const appContext = useContext(AppContext);

  return (
    <Fragment>
      <form className={classes.form} onSubmit={submitHandler}>
        <h5>Add & Update Product</h5>
        <Input
          label="Name"
          input={{
            id: "name",
            type: "text",
            value: formInput.name,
            required: "required",
            onChange: (event) => {
              setFormInput((prevState) => ({
                ...prevState,
                name: event.target.value,
              }));
            },
          }}
        />
        <Input
          label="Description"
          input={{
            id: "description",
            type: "text",
            value: formInput.description,
            required: "required",
            onChange: (event) => {
              setFormInput((prevState) => ({
                ...prevState,
                description: event.target.value,
              }));
            },
          }}
        />
        <Input
          label="Quantity"
          input={{
            id: "quantity",
            type: "number",
            value: formInput.quantity,
            required: "required",
            onChange: (event) => {
              setFormInput((prevState) => ({
                ...prevState,
                quantity: event.target.value,
              }));
            },
          }}
        />
        <Input
          label="Price"
          input={{
            id: "price",
            type: "text",
            value: formInput.price,
            required: "required",
            onChange: (event) => {
              setFormInput((prevState) => ({
                ...prevState,
                price: event.target.value,
              }));
            },
          }}
        />
        <div className={classes.input}>
          <label>Category</label>
          <select
            required
            value={formInput.categoryId && formInput.categoryId}
            onChange={(event) => {
              setFormInput((prevState) => ({
                ...prevState,
                categoryId: event.target.value,
              }));
            }}
          >
            <option value="">Select Category</option>
            {appContext.categoryList.map((x) => (
              <option key={x.id} value={x.id}>
                {x.name}
              </option>
            ))}
          </select>
        </div>

        <div style={{ display: "flex", justifyContent: "center" }}>
          <button
            type="button"
            onClick={() =>
              setFormInput({
                id: "",
                name: "",
                description: "",
                quantity: "",
                price: "",
                categoryId: "",
              })
            }
            style={{ padding: "1rem 2rem" }}
          >
            Reset
          </button>
          <button type="submit" style={{ padding: "1rem 2rem" }}>
            Send
          </button>
        </div>
      </form>
    </Fragment>
  );
};

export default ProductForm;
