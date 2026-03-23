import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { PersonList } from "./person/PersonList";
import { PersonCreate } from "./person/PersonCreate";
import { PersonEdit } from "./person/PersonEdit";
import { PersonShow } from "./person/PersonShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"nodejsApp"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Person"
          list={PersonList}
          edit={PersonEdit}
          create={PersonCreate}
          show={PersonShow}
        />
      </Admin>
    </div>
  );
};

export default App;
