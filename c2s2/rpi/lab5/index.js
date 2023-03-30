const express = require('express')
const bodyParser = require('body-parser');
const app = express()
const port = 3000

app.use("*/js", express.static("public/js"));
app.use("*/css", express.static("public/css"));
app.use("*/images", express.static("public/images"));
app.use(bodyParser.urlencoded({ extended: true }));
app.set("view engine", "ejs");

const answers = [
  {
    question: "In which function start execute program in c++",
    answer: "main()",
    image: null,
    id: 0
  },
  {
    question: "What is the capital of England?",
    answer: "jdied",
    image: null,
    id: 1
  },
  {
    question: "What is the capital of Germany?",
    answer: "H",
    image: "/images/senet.jpg",
    alt: "senet",
    id: 2
  }
];

app.get('/', (req, res) => {
  res.render("index", {
    answers: answers,
  });
})

var mark = 0;
app.post("/", (req, res) => {
  for(var i = 0; i < answers.length; i++) {
    console.log(answers[i].answer);
    console.log(req.body[i]);
      if(answers[i].answer === req.body[i]) {
        mark++;
      }
  }
  res.redirect("/results");
})  

app.get('/results', (req, res) => {
  res.render("results", {
    mark: mark
  });
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})