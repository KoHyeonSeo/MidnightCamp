const getConnection = require('../database/connection');
const ModelRepository = require('../repositories/model-repo')

exports.searchAllModels = () => {
    return new Promise((resolve, reject) => {
        const connection = getConnection();
        const results = ModelRepository.selectAllModels(connection);
        connection.end();
        resolve(results);
    })
}

exports.searchModels = (data) => {
    return new Promise((resolve, reject) => {
        console.log(data);
        const type = data.type;
        
        console.log(type);
        const connection = getConnection();
        let results = [];
        if(type === 'id'){
            console.log("여기까지 왔습니다.")
            const id = data.id;
            results = ModelRepository.selectModelsByGroupId(connection, id);
        }
        else if(type === 'name'){
            const name = data.name;
            results = ModelRepository.selectModelsByModelName(connection, name);
        }
        connection.end();
        resolve(results);
    })
}