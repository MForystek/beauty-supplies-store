import { useState } from "react";
import Alert from "./components/Alert";
import DisplayButton from "./components/DisplayButton";
import ListGroup from "./components/ListGroup";

function App() {
  let items = ["lipstick", "shampoo", "i don't know more beauty supplies"];
  const [showAlert, setShowAlert] = useState(false);

  const handleSelectItem = (item: string) => {
    console.log(item);
  };

  const handleClickButton = () => {
    setShowAlert(true);
  };

  return (
    <>
      {showAlert && <Alert onClose={() => setShowAlert(false)}>clicked</Alert>}
      <DisplayButton onClick={handleClickButton}>show alert</DisplayButton>
      <ListGroup items = {items} heading="Beauty supplies store" onSelectItem={() => {}}></ListGroup>
    </>
  );
}

export default App;
