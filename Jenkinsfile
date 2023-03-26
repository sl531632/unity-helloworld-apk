pipeline {
    agent {
        docker {
            image 'unityci/editor:2020.3.10f1-ubuntu20.04'
            args '-u root:root -v /tmp/.X11-unix:/tmp/.X11-unix:rw --privileged'
        }
    }
    stages {
        stage('Build') {
            steps {
                sh '''
                    xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' /opt/unity/Editor/Unity \
                    -quit \
                    -batchmode \
                    -logfile ./unity-build.log \
                    -customBuildPath ./output/build \
                    -executeMethod BuildScript.BuildAndroid
                '''
            }
        }
        stage('Archive') {
            steps {
                archiveArtifacts artifacts: 'output/build/**/*', fingerprint: true
            }
        }
    }
}
