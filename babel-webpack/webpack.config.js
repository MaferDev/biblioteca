const path = require('path');
const HtmlWebpackPlugin=require('html-webpack-plugin');
const MiniCssExtractPlugins = require('mini-css-extract-plugin');

module.exports={
    entry:{        
        app:[
            '@babel/polyfill',
            './src/app/index.js'
        ]
    },
    output:{
        path: path.resolve(__dirname,'build'),
        filename: 'js/app.bundle.js'
    },
    devServer:{
        port:4000
    },
    module:{
        rules:[
            {
                test: /\.js$/,
                loader: 'babel-loader'
            },
            {
                test: /\.css$/,
                use: [
                    MiniCssExtractPlugins.loader,
                    'css-loader'
                ]
            }
        ]
    },
    plugins:[
        new HtmlWebpackPlugin({            
            template:'./src/index.html',
            minify:{
                collapseWhitespace: true,
                removeComments: true,
                removeRedundantAttributes: true,
                removeScriptTypeAttributes: true,
                removeStyleLinkTypeAttributes: true,
                useShortDoctype: true
            }
        }),
        new MiniCssExtractPlugins({
            filename:'css/app.bundle.css'
        })
    ]
}