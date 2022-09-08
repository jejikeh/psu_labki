import React from "react";

export const Button = ({children}) => {
    return (
        <div className="bgbut">
        <button className="but">{children}</button>
        </div>
    );
}