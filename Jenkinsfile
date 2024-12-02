pipeline {
  agent any
  stages {
    stage('checkout code  / Git ') {
      steps {
        git(url: 'https://github.com/Zidane-Aboukhalid/Auth_services', branch: 'dev', changelog: true)
      }
    }

  }
}
