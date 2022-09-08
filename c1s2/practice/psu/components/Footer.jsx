import React from "react";
import Image from "next/image";
import NavItem from "./NavItem";


const MenuList = [
    {
        text : "Научная Библиотека",
        href : "/",
    },
    {
        text : "Научная Библиотека",
        href : "/",
    },
    {
        text : "Карта Сайта",
        href : "/",
    },
    {
        text : "О нас в СМИ",
        href : "/",
    },
    {
        text : "Одно окно",
        href : "/",
    },
    {
        text : "Официальные ссылки",
        href : "/",
    },
    {
        text : "Контакты",
        href : "/",
    },
]

export const Footer = ({children}) => {
    return (
        <div className="footer">
            <div className="devider">
                <div className="line"></div>
            </div>
            <div className="navbar">
                        {
                            MenuList.map((menu,idx) => {
                                return <div key={menu.text}>
                                    <NavItem {...menu}/>
                                </div>
                            })
                        }
            </div>
            <div className="ender">
                <div className="navbar">
                    <Image src="/Vector.svg" width={64} height={64}/>
                    <div className="enderH">
                    <h1>Полоцкий Государственный Университет
имени Ефросинии Полоцкой</h1>
</div>
                </div>
            </div> 
        </div>
    );
}