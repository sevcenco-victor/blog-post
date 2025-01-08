import {ChangeEventHandler, ComponentPropsWithoutRef} from "react";

export type InputProps = ComponentPropsWithoutRef<'input'> & {
    name: string;
    onChange: ChangeEventHandler<HTMLInputElement>;
}