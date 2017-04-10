module.exports = {
  extends: "airbnb",
  parser: "babel-eslint",
  rules: {
    "graphql/template-strings": ['error', {
      
      env: 'apollo',

      schemaJson: require('./src/data/schema.json'),
    }],
    "linebreak-style": 0,
    "react/jsx-filename-extension": [1, { "extensions": [".js", ".jsx"] }],
    "comma-dangle": ["error", "never"],
    "no-underscore-dangle": ["error", { "allowAfterThis": true }]
  },
  globals: {
    "document": true,
    "window": true
  },
  plugins: [
    'graphql'
  ]
}