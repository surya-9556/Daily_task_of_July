var Db = require('./dboperations');
var Movies = require('./Movies');
const dboperations = require('./dboperations');

var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');
var app = express();
var router = express.Router();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(cors());
app.use('/api', router);

router.use((request,response,next)=>{
    console.log('middleware');
    next();
 })

 router.route('/Movies').get((request,response)=>{

    dboperations.getMovies().then(result => {
       response.json(result[0]);
    })

})

var port = process.env.PORT || 8091;
app.listen(port);
console.log('Student API is runnning at ' + port);