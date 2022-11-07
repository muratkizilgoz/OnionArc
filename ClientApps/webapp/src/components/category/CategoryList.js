import React, { Fragment, useContext } from "react";
import { AppContext } from "../../context/app-context";
import Card from "../ui/Card";
import classes from "./CategoryList.module.css";

const CategoryList = ({ setFormInput, removeHandler }) => {
  const appContext = useContext(AppContext);

  const categoryList = appContext.categoryList.map((x) => {
    return (
      <div className={classes.category} key={x.id}>
        <div
          onClick={() =>
            setFormInput(appContext.categoryList.find((y) => y.id === x.id))
          }
        >
          <Card>
            <ul>
              <li>Name: {x.name}</li>
              <li>Description: {x.description}</li>
            </ul>
          </Card>
        </div>
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
              removeHandler(appContext.categoryList.find((y) => y.id === x.id))
            }
          >
            Remove
          </button>
        </div>
      </div>
    );
  });

  return <Fragment>{categoryList}</Fragment>;
};

export default CategoryList;
