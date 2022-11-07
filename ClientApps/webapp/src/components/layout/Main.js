import React, { Fragment } from "react";
import classes from "./Main.module.css";

const Main = (props) => {
  return (
    <Fragment>
      <main className={classes.main}>{props.children}</main>
    </Fragment>
  );
};

export default Main;
