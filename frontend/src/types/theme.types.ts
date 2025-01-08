export type ThemeTypes = 'dark' | 'light';

export type ThemeStore = {
    theme: ThemeTypes;
    switchTheme: () => void;
}