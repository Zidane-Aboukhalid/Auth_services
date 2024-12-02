pipeline {
  agent any
  stages {
    stage('checkout code ') {
      steps {
        git(url: 'https://github.com/Zidane-Aboukhalid/Auth_services', branch: 'main')
      }
    }

    stage('adds logs') {
      steps {
        sh 'ls -la'
      }
    }

  }
}