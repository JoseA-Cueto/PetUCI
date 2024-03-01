const path = require('path');
const { VueLoaderPlugin} = require('vue-loader');

module.exports = {
    entry: './wwwroot/js/app.js',
    output: {
        filename: 'main.js',
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: 'bundle.js'
    },
    module: { 
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use:{
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env']
                    }
                }
                
            },
            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            }
        ]
            ,
        },
        plugins: [
            new VueLoaderPlugin()
        ], 
        externals: {
            vue: 'Vue'
        }

}