const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCssAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const path = require("path");

module.exports = (env, argv) => {
    return {
      resolve: {
        alias: {
          ...(argv.mode === "development" ?
               {
                 "react-dom": "@hot-loader/react-dom",
                 "api.config$": path.resolve(__dirname, "src/app/api/api.development.js")
               } :
               {
                 "api.config$": path.resolve(__dirname, "src/app/api/api.production.js")
               })
        }
      },
      entry: [
        "react-hot-loader/patch",
        "./src"
      ],
      output: {
        filename: "main.js"
      },
      module: {
        rules: [
          {
            test: /\.(js|jsx)$/,
            exclude: /node_modules/,
            use: {
              loader: "babel-loader"
            }
          },
          {
            test: /\.css$/,
            exclude: /node_modules/,
            use: [
              {
                loader: MiniCssExtractPlugin.loader,
                options: {
                  hmr: argv.mode === "development"
                }
              },
              "css-loader"
            ]
          },
          {
            test: /\.html$/,
            exclude: /node_modules/,
            use: {
              loader: "html-loader",
              options: {
                minimize: argv.mode === "production"
              }
            }
          },
          {
            test: /\.(png|svg|jpg|gif)$/,
            exclude: /node_modules/,
            use: ["file-loader"]
          }
        ]
      },
      devServer: {
        hot: true,
        historyApiFallback: true
      },
      plugins: [
        new HtmlWebpackPlugin({
          base: {
            href: "/"
          },
          template: "./src/index.html",
          filename: "./index.html",
          hash: true,
        }),
        new MiniCssExtractPlugin(),
        ...(argv.mode === "production" ? [ new OptimizeCssAssetsPlugin({
          cssProcessorPluginOptions: {
            preset: ["default", { discardComments: { removeAll: true } }]
          }
        })] : [])
      ]
    };
  };