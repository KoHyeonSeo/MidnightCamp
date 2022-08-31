const jwt = require('jsonwebtoken');
const secret = 'test-secret';

const authMiddleware = (req, res, next) => {
    const accessToken = req.header('AccessToken');
    let payload;
    if(!accessToken) {
        res.status(401).json({ success: false, message: '로그인 정보가 없습니다.' });
    } else {
        jwt.verify(accessToken, secret, (err, decoded) => {
            payload = decoded;
        }); 
        console.log(payload);
        next();
    }
}

module.exports = authMiddleware;