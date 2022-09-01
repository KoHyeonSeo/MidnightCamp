const express = require('express');
const morgan = require('morgan');
const cors = require('cors');

const app = express();

app.use(morgan('dev'));
app.use(express.json());
app.use(cors());

const authRouter = require('./src/routes/auth-route');
const modelRouter = require('./src/routes/model-route');

app.use(express.static('public'));
app.use('/auth', authRouter);
app.use('/model', modelRouter);

app.listen(8888, () => console.log('listening on port 8888...'));

