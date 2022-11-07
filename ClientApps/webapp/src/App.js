import "./App.css";
import { AppContext } from "./context/app-context";
import { Fragment, useContext, useRef, useState } from "react";
import Layout from "./components/layout/Layout";
import { Route, Routes } from "react-router-dom";
import Home from "./Pages/Home";
import Category from "./Pages/Category";
import Product from "./Pages/Product";
import Input from "./components/ui/Input";

function App() {
  const appContext = useContext(AppContext);
  const [loginInput, setLoginInput] = useState({
    email: "",
    password: "",
  });

  return (
    <Fragment>
      <Layout>
        {appContext.isLoggedIn ? (
          <Routes>
            <Route exact path="/">
              <Route path="/" element={<Home />} />
              <Route path="category" element={<Category />} />
              <Route path="product" element={<Product />} />
            </Route>
          </Routes>
        ) : (
          <form
            onSubmit={(event) => {
              event.preventDefault();
              appContext.loginHandler(loginInput);
            }}
            style={{ marginTop: "5rem" }}
          >
            <Input
              label="Email"
              input={{
                id: "email",
                type: "email",
                value: loginInput.email,
                required: "required",
                onChange: (event) => {
                  setLoginInput((prevState) => ({
                    ...prevState,
                    email: event.target.value,
                  }));
                },
              }}
            />
            <Input
              label="Password"
              input={{
                id: "password",
                type: "password",
                value: loginInput.password,
                required: "required",
                onChange: (event) => {
                  setLoginInput((prevState) => ({
                    ...prevState,
                    password: event.target.value,
                  }));
                },
              }}
            />
            <div style={{ display: "flex", justifyContent: "center" }}>
              <button type="submit" style={{ padding: "1rem 2rem" }}>
                Send
              </button>
            </div>
          </form>
        )}
      </Layout>
    </Fragment>
  );
}

export default App;
