
## 利用Swagger文档 生成 WebAPI访问客户端

    最终使用效果

    nuget安装=》修改配置文件ApiConfig.json=>打开Nuget控制管理台 执行命令WebApiClient-Generate-Invoke=》生成了最终文件

**关键点**

### Swagger2 文档

    详细了解Swagger2 文档 规范，从中解析出我们生成客户端代码需要元素

### 代码生成模板引擎 -T4

    
    运行时模板

###  采用开源项目 Refit (https://reactiveui.github.io/refit/)
     
     开源社区还有一个开源项目是国内人写的 WebApiClient（灵感也是来自Refit），看了社区活跃度 以及成熟度 我选择了 Refit。这块我们可以讨论

### 接入服务发现

    前期实现Consul服务发现


### Nuget打包


### 最后考虑Netcore支持