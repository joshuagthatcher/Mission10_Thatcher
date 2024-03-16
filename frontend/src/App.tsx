import React, { useState } from "react";
import "./App.css";
import Header from "./header";
import BowlerList from "./Bowlers/BowlerList";

function App() {
  return (
    <div className="App">
      <Header />
      <BowlerList />
    </div>
  );
}

export default App;
