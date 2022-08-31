const wrapAsyncContoller = (fn) => {
    return (req, res, next) => {
        fn(req, res, next).catch(next)
    }
}

module.exports = wrapAsyncContoller;