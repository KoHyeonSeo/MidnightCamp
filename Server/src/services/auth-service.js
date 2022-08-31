const { response } = require('express');
const getConnection = require('../database/connection');
const AuthRepository = require('../repositories/auth-repo');

exports.login = async (data) => {
    return new Promise(async (resolve, reject) => {
        const connection = getConnection();
        const result = await AuthRepository.selectUserByIdAndPassword(connection, data);

        resolve(result);
        
        connection.end();
    })
}

exports.registAuth = async (data) => {
    return new Promise(async (resolve, reject) => {
        const connection = getConnection();
        connection.beginTransaction();

        try {
            const result = await AuthRepository.insertAuth(connection, data);

            connection.commit();
            resolve(result);
        }catch(err){
            connection.rollback();
            reject(err);
        }finally{
            connection.end();
        }

    })
}