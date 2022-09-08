import React from "react";
import Link from "next/link";
import NavItem from "./NavItem";
import Image from "next/image";

const MenuList = [
    {
        text : "Университет",
        href : "/",
    },
    {
        text : "Студентам",
        href : "/",
    },
    {
        text : "Абиритуриентам",
        href : "/",
    },
    {
        text : "Иностранным гражданам",
        href : "/",
    },
]

const Navbar = () => {
    return (
        <header>
            <nav className="navbar">
                <Image src="/Vector.svg" width={32} height={32}/>
                <Link href={"/"}>
                <a>
                    <h1 className="logo">PSU.BY</h1>
                </a>
                </Link>

                <div className="navbar">
                    {
                        MenuList.map((menu,idx) => {
                            return <div key={menu.text}>
                                <NavItem {...menu}/>
                            </div>
                        })
                    }
                </div>
            </nav>
        </header>
    )
}

export default Navbar;