import React, { useEffect, useState } from "react";
import { AppContext } from "./app-context";

const AppContextProvider = (props) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [categoryList, setCategoryList] = useState([]);
  const [isCategoryCrud, setIsCategoryCrud] = useState(false);
  const [isProductCrud, setIsProductCrud] = useState(false);
  const [productList, setProductList] = useState([]);
  const [token, setToken] = useState();

  useEffect(() => {
    const getCategories = async () => {
      const response = await fetch(
        `${process.env.REACT_APP_API_URL}/Category`,
        {
          method: "get",
          mode: "cors",
          headers: getHeaders(),
        }
      );
      if (response.ok) {
        const responseData = await response.json();
        setCategoryList(responseData);
      }
    };
    isLoggedIn && getCategories();
  }, [isCategoryCrud, isLoggedIn]);

  useEffect(() => {
    const getProducts = async () => {
      const response = await fetch(`${process.env.REACT_APP_API_URL}/Product`, {
        method: "get",
        mode: "cors",
        headers: getHeaders(),
      });
      if (response.ok) {
        const responseData = await response.json();
        setProductList(responseData);
      }
    };
    isLoggedIn && getProducts();
  }, [isProductCrud, isLoggedIn]);

  const getHeaders = () => {
    return {
      Authorization: `Bearer ${token}`,
      Accept: "application/json, text/plain",
      "Content-Type": "application/json;charset=UTF-8",
    };
  };

  const crudCategory = (category, patch) => {
    switch (patch) {
      case "ADD":
        createCategory(category);
        break;
      case "UPDATE":
        updateCategory(category);
        break;
      case "DELETE":
        deleteCategory(category);
        break;
      default:
        break;
    }
  };

  const createCategory = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Category`, {
      method: "post",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsCategoryCrud(!isCategoryCrud);
    }
  };

  const deleteCategory = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Category`, {
      method: "delete",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsCategoryCrud(!isCategoryCrud);
    }
  };

  const updateCategory = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Category`, {
      method: "put",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsCategoryCrud(!isCategoryCrud);
    }
  };

  const crudProduct = (product, patch) => {
    switch (patch) {
      case "ADD":
        createProduct(product);
        break;
      case "UPDATE":
        updateProduct(product);
        break;
      case "DELETE":
        deleteProduct(product);
        break;
      default:
        break;
    }
  };

  const createProduct = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Product`, {
      method: "post",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsProductCrud(!isProductCrud);
    }
  };

  const deleteProduct = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Product`, {
      method: "delete",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsProductCrud(!isProductCrud);
    }
  };

  const updateProduct = async (data) => {
    const response = await fetch(`${process.env.REACT_APP_API_URL}/Product`, {
      method: "put",
      mode: "cors",
      headers: getHeaders(),
      body: JSON.stringify(data),
    });
    if (response.ok) {
      setIsProductCrud(!isProductCrud);
    }
  };

  const loginHandler = async (data) => {
    const response = await fetch(
      `${process.env.REACT_APP_API_URL}/Account/Login`,
      {
        method: "post",
        mode: "cors",
        headers: getHeaders(),
        body: JSON.stringify(data),
      }
    );
    if (response.ok) {
      const responseData = await response.json();
      setToken(responseData);
      setIsLoggedIn(true);
    }
  };

  return (
    <AppContext.Provider
      value={{
        categoryList,
        crudCategory,
        productList,
        crudProduct,
        setProductList,
        isLoggedIn,
        loginHandler,
      }}
    >
      {props.children}
    </AppContext.Provider>
  );
};

export default AppContextProvider;
