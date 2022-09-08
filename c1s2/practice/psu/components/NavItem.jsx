import Link from 'next/link'
import React from 'react'
import Image from "next/image";


const NavItem = ({href, text, active}) => {
    return (
        <Link href={href}>
            <a className={`nav__link ${active ? 'active' : ''}`}>{text  }</a>
        </Link>
    )
}

export default NavItem;