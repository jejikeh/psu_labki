import React from "react";
import Image from "next/image";

export const Card = ({children}) => {
    return (
        <div className="card">
            <Image className="cardimage" src="/b.jpg" width={267} height={160}/>
        <h1 className="cardText">{children}</h1>
        </div>
    );
}