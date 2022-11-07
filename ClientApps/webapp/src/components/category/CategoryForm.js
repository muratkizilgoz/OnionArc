import React, { Fragment } from "react";
import Input from "../ui/Input";
import classes from "./CategoryForm.module.css";

const CategoryForm = ({ formInput, setFormInput, submitHandler }) => {
  return (
    <Fragment>
      <form className={classes.form} onSubmit={submitHandler}>
        <h5>Add & UpdateCategory</h5>
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
        <div style={{ display: "flex", justifyContent: "center" }}>
          <button
            type="button"
            onClick={() =>
              setFormInput({
                id: "",
                name: "",
                description: "",
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

export default CategoryForm;
