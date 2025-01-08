import {create} from 'zustand';
import {ThemeTypes, ThemeStore} from "@/types";


let pickedTheme: ThemeTypes = localStorage.getItem('theme') as ThemeTypes;

if (!pickedTheme) {
    pickedTheme = window.matchMedia("(prefers-color-scheme:dark)").matches ? 'dark' : 'light';
}

export const useThemeStore = create<ThemeStore>((set) => {
    return {
        theme: pickedTheme,
        switchTheme: () => set((state) => {
            const newTheme = state.theme === "dark" ? "light" : "dark";
            localStorage.setItem("theme", newTheme);
            return {theme: newTheme};
        }),
    };
});