import React, { Children, ReactNode } from "react";

interface Props {
  children: ReactNode;
  color?: 'primary' | 'secondary' | 'dark';
  onClick: () => void;
}

const DisplayButton = ({ children, onClick, color = 'dark'}: Props) => {
  return (
    <button type="button" className={"btn btn-" + color} onClick={onClick}>
      {children}
    </button>
  );
};

export default DisplayButton;
