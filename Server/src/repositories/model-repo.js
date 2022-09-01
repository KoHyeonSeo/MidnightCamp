const modelQuery = require('../database/model-query');
const ModelDTO = require('../dto/model-respose-dto');
const ObjectDTO = require('../dto/object-respose-dto');

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

exports.selectModelsByGroupId = (connection, keyword) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectModelsByGroupId(), [keyword],(err, results, fields) => {

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

exports.selectModelsByModelName = (connection, keyword) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectModelsByModelName(), [`%${keyword}%`],(err, results, fields) => {

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

exports.selectModelsByModelName = (connection, code) => {
    return new Promise((resolve, reject) => {
        connection.query(modelQuery.selectModelDetailByCode(), [code],(err, results, fields) => {

            if(err) {
                console.log('err', err);
                reject(err);
            }

            console.log('results: ', results);

            const objects = [];
            for(let i = 0; i < results.length; i++) {
                objects.push(new ObjectDTO(results[i]));
            }
            resolve(objects);
        });
    });
}