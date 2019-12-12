const mqtt = require ('mqtt');
var client   = mqtt.connect('mqtt://192.168.102.76');
const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');

  // Connection URL
  const url = 'mongodb://localhost:27017';

  const dbName = 'Calcio-Balilla';
  
  MongoClient.connect(url, function(err, client) {
      assert.equal(null, err);
      console.log("Connected successfully to server");
     
      const db = client.db(dbName);
     
      client.close();
  });

client.on('connect', function () {
      client.subscribe('/Richieste');
      console.log('client has subscribed successfully');
  });

  client.on('message', function (topic, message){
      console.log(message.toString()); //if toString is not given, the message comes as buffer

      
      var obj1 = JSON.parse(message.toString());
    
    
      MongoClient.connect(url, function(err, db) {
          if (err) throw err;
          var dbo = db.db("Calcio-Balilla");
          var myobj = { idCampo:obj1.idCampo, idPartita:obj1.idPartita,  team: obj1.team, Event: obj1.Event, EventResult:obj1.EventResult, pTeam1: obj1.pTeam1, pTeam2: obj1.pTeam2 };
          dbo.collection("DatiPartita").insertOne(myobj, function(err, res) {
                  if (err) throw err;
                  console.log("1 document inserted");
                  db.close();
          });
        });
  });


