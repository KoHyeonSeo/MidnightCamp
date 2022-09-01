const getConnection = require('../database/connection');
const ModelRepository = require('../repositories/model-repo');

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
        if(type === 'groupId'){
            const keyword = data.keyword;
            console.log("그룹아이디로 검색", keyword);
            results = ModelRepository.selectModelsByGroupId(connection, keyword);
        }
        else if(type === 'modelName'){
            const keyword = data.keyword;
            results = ModelRepository.selectModelsByModelName(connection, keyword);
        }
        connection.end();
        resolve(results);
    })
}

exports.searchDetailByCode = (code) => {
    return new Promise((resolve, reject) => {
        
        console.log(code);
        const connection = getConnection();

        const results = ModelRepository.selectModelDetailByCode(connection);
        connection.end();
        resolve(results);
    })
}