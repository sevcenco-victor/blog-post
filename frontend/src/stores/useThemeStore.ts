import {create} from 'zustand';
import {Theme} from "../types";

const userPreference = window.matchMedia("(prefers-color-scheme: dark)").matches;

export const useThemeStore = create<Theme>((set) => {
    return {
        isDark: userPreference,
        switchTheme: () => set((state) => ({isDark: !state.isDark})),
    };
});