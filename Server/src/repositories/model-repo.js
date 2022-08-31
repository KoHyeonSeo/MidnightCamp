const modelQuery = require('../database/model-query');
const ModelDTO = require('../dto/model-respose-dto');

exports.selectAllModels = (connection) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectAllModels(), (err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            const models = [];
            for(let i = 0; i < results.length; i++) {
                models.push(new ModelDTO(results[i]));
            }
            resolve(models);
        });
    });
}

exports.selectModelsByGroupId = (connection, id) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectModelsByGroupId(), [id],(err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            const models = [];
            for(let i = 0; i < results.length; i++) {
                models.push(new ModelDTO(results[i]));
            }
            resolve(models);
        });
    });
}

exports.selectModelsByModelName = (connection, name) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectModelsByModelName(), [`%${name}%`],(err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            const models = [];
            for(let i = 0; i < results.length; i++) {
                models.push(new ModelDTO(results[i]));
            }
            resolve(models);
        });
    });
}