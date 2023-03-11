const express = require('express')
const app = express()
const port = 3000

app.use("*/js", express.static("public/js"));
app.use("*/css", express.static("public/css"));
app.use("*/images", express.static("public/images"));
app.set("view engine", "ejs");

app.get('/', (req, res) => {
  res.render("index");
})

app.get('/test', (req, res) => {
  res.render("test");
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})