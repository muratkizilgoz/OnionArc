import React, { Fragment, useContext, useState } from "react";
import CategoryForm from "../components/category/CategoryForm";
import CategoryList from "../components/category/CategoryList";
import { AppContext } from "../context/app-context";

const Category = () => {
  const [formInput, setFormInput] = useState({
    id: "",
    name: "",
    description: "",
  });

  const appContext = useContext(AppContext);

  const submitHandler = (event) => {
    event.preventDefault();
    let patch = "ADD";
    if (formInput.id.length !== 0) {
      patch = "UPDATE";
    }
    appContext.crudCategory(formInput, patch);
    setFormInput({
      id: "",
      name: "",
      description: "",
    });
  };

  const removeHandler = (category) => {
    appContext.crudCategory(category, "DELETE");
    setFormInput({
      id: "",
      name: "",
      description: "",
    });
  };

  return (
    <Fragment>
      <h3>Category</h3>
      <div style={{ display: "flex", flex: "1" }}>
        <div style={{ display: "flex", flexDirection: "column", flex: "1" }}>
          <CategoryList
            setFormInput={setFormInput}
            removeHandler={removeHandler}
          />
        </div>
        <div style={{ display: "flex", flex: "1" }}>
          <CategoryForm
            formInput={formInput}
            setFormInput={setFormInput}
            submitHandler={submitHandler}
          />
        </div>
      </div>
    </Fragment>
  );
};

export default Category;
