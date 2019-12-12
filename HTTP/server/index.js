var restify = require('restify');
const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');

var server = restify.createServer();
server.use(restify.plugins.bodyParser());
 
// Connection URL
const url = 'mongodb://localhost:27017';

const dbName = 'prova';

MongoClient.connect(url, function(err, client) {
    assert.equal(null, err);
    console.log("Connected successfully to server");
   
    const db = client.db(dbName);
   
    client.close();
});






server.get('/tables', function(req, res, next) {
    res.send('List of tables: [TODO]');
    return next();
});

server.get('/tables/:serial', function(req, res, next) {
    res.send('Current values for table ' + req.params['serial'] + ': [TODO]');
    return next();
});

server.post('/tables/:serial', function(req, res, next) {
    res.send('Data received from table [TODO]');


  
    console.log(req.body);
    var obj1 = JSON.parse(req.body);
 

    MongoClient.connect(url, function(err, db) {
        if (err) throw err;
        var dbo = db.db("prova");
        var myobj = { idCampo:obj1.idCampo, idPartita:obj1.idPartita,  team: obj1.team, Event: obj1.Event, EventResult:obj1.EventResult, pTeam1: obj1.pTeam1, pTeam2: obj1.pTeam2 };
        dbo.collection("prova").insertOne(myobj, function(err, res) {
                if (err) throw err;
                console.log("1 document inserted");
                db.close();
        });
      });

    return next();
});

server.listen(8011, function() {
    console.log('%s listening at %s', server.name, server.url);
});
