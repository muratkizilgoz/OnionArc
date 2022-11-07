import React from "react";

export const AppContext = React.createContext({
  categoryList: [],
  productList: [],
  crudCategory: (category, patch) => {},
  crudProduct: (product, patch) => {},
  setProductList: () => {},
  isLoggedIn: false,
  loginHandler: () => {},
});
