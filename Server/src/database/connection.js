const mysql = require('mysql');
const connectionInfo = require('../config/db-config');

console.log(connectionInfo);
const getConnection = () => { 

    return mysql.createConnection(connectionInfo); 
}

module.exports = getConnection;