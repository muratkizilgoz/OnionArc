import React, { Fragment } from "react";
import Main from "../components/layout/Main";
import ProductList from "../components/product/ProductList";

const Home = () => {
  return (
    <Fragment>
      <Main>
        <ProductList />
      </Main>
    </Fragment>
  );
};

export default Home;
