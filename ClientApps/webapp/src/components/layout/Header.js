import React, { Fragment } from "react";
import { Link, NavLink } from "react-router-dom";
import classes from "./Header.module.css";

export const Header = () => {
  let activeStyle = {
    textDecoration: "underline",
  };
  return (
    <Fragment>
      <header className={classes.header}>
        <h1>Sample Store</h1>
        <nav>
          <ul>
            <li>
              <NavLink
                to="/"
                style={({ isActive }) => (isActive ? activeStyle : undefined)}
              >
                Home
              </NavLink>
            </li>
            <li>
              <NavLink
                to="/category"
                style={({ isActive }) => (isActive ? activeStyle : undefined)}
              >
                Category
              </NavLink>
            </li>
            <li>
              <NavLink
                to="/product"
                style={({ isActive }) => (isActive ? activeStyle : undefined)}
              >
                Product
              </NavLink>
            </li>
          </ul>
        </nav>
      </header>
    </Fragment>
  );
};

export default Header;
