const authQuery = require('../database/auth-query');

exports.selectUserByIdAndPassword = (connection, data) => {
    const {id, password} = data;
    return new Promise((resolve, reject) => {
        connection.query(authQuery.selectUserByIdAndPassword(), [id, password], (err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            resolve(results);
        });
    });
};

exports.insertAuth = (connection, data) => {
    const {id, password, name} = data;
    return new Promise((resolve, reject) => {
        connection.query(authQuery.insertAuth(), [id, password, name], (err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            resolve(results);
        })
    })
}