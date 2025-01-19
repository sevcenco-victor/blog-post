import {ComponentPropsWithoutRef, ReactNode} from "react";

export type FormLabelProps = {
    text: string;
    children?: ReactNode;
}
export type FormProps = ComponentPropsWithoutRef<'form'> & {
    children: ReactNode;
}