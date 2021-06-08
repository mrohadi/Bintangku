const defaultTheme = require('tailwindcss/defaultTheme');

const blue= {
  50: '#1DA1F2', // twitter icon bg
  100: '#66CBFF', // Blue - Sky
  200: '#bfdbfe',
  300: '#32CCFE', // Blue - Sky Lighter
  400: '#2867B2', // linkedin icon bg
  500: '#5D9FE2', // Blue - Light
  600: '#2563eb',
  700: '#003466', // Blue - Dark
  800: '#3C5A99', // facebook icon bg
  900: '#06275D', // Blue - Black Alt
};
const yellow= {
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
};
const red = {
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
    colors:{
      ...defaultTheme.colors,
      black: '#323232',
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
