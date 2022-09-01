const HttpStatus = require('http-status');
const AuthService = require('../services/auth-service');
const jwt = require('jsonwebtoken');
const secret = 'test';

exports.login = async (req, res, next) => {
    const data = req.body
    const results = await AuthService.login(data);
    if(!results || results.length == 0){
        res.status(401).json({ success: false, message: '아이디 혹은 패스워드 불일치' });
    }
    else{
        const result = results[0]
        jwt.sign(
            {
                id: result.group_id,
                name: result.group_name
            },
            secret,
            {
                    expiresIn: '3d'
            },
            (err, token) => {
                if(err) {
                    console.log(err);
                    res.status(401).json({ success: false, message: '토큰 발급 실패!' });
                } else {
                    /* https://jwt.io/  여기서 확인 가능함 */
                    res.status(200).json({ success: true, accessToken: token });
                }
            }
        );
    };
};


exports.regist = async (req, res, next) => {
    const data = req.body;
    const results = await AuthService.registAuth(data);

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found Diary by No',
        results: results
    })
}