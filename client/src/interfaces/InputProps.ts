import { ChangeEventHandler } from "react";

export interface InputProps {
    onChange?: ChangeEventHandler<HTMLInputElement>;
    placeholder?: string;
    name: string;
    width?: string;
}