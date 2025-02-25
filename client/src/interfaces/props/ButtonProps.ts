export interface ButtonProps {
    type?: "submit" | "reset" | "button" | undefined;
    onClick?: () => void;
    children: string;
    width?: string;
    textColor?: string;
    bgColor?: string;
}