const defaultTheme = require('tailwindcss/defaultTheme');

const blue= {
  50: '#eff6ff',
  100: '#66CBFF', // Blue - Sky
  200: '#bfdbfe',
  300: '#32CCFE', // Blue - Sky Lighter
  400: '#60a5fa',
  500: '#5D9FE2', // Blue - Light
  600: '#2563eb',
  700: '#003466', // Blue - Dark
  800: '#1e40af',
  900: '#06275D', // Blue - Black Alt
},
yellow= {
  50: '#fefce8',
  100: '#FFCC66', // Yellow - light
  200: '#FFC000', // Yellow - Most Orange
  300: '#FE9900', // Orange
  400: '#facc15',
  500: '#eab308',
  600: '#ca8a04',
  700: '#a16207',
  800: '#854d0e',
  900: '#713f12',
},red = {
  50: '#fefce8',
  100: '#FECCCB',
  200: '#FFC000',
  300: '#FECCCB', //Red - peach
  400: '#FF679A', //Red - Pink
  500: '#FF6766', //Red - Bata
  600: '#FF3366', //Red - Maroon
  700: '#a16207',
  800: '#854d0e',
  900: '#713f12',
};
module.exports = {
  purge: {
    enabled: true,
    content: [
      './src/**/*.html',
      './src/**/*.scss'
    ]
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    color:{
      ...defaultTheme.colors,
      blue,
      red,
      yellow
    },
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
