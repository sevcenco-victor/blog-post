import {ComponentPropsWithoutRef, ReactNode} from "react";
import {NavLink} from "react-router-dom";

export type MenuBarGroupProps = MenuBarProps & {
    groupName: string;
}

export type MenuBarItemProps = ComponentPropsWithoutRef<typeof NavLink> & {
    text: string;
}

export type MenuBarProps = {
    children: ReactNode;
}