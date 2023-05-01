const express = require('express')
const bodyParser = require('body-parser');
const app = express()
const port = 3000

app.use("*/js", express.static("public/js"));
app.use("*/css", express.static("public/css"));
app.use("*/images", express.static("public/images"));
app.use("*/font", express.static("public/font"));
app.use(bodyParser.urlencoded({ extended: true }));
app.set("view engine", "ejs");

app.get('/', (req, res) => {
  res.render("index");
})

app.get('/2', (req, res) => {
  res.render("index2");
})

app.get('/3', (req, res) => {
  res.render("index3");
})

app.get('/4', (req, res) => {
  res.render("index4");
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})