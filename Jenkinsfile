pipeline {
    agent {
        docker {
            image 'unityci/editor:ubuntu-2022.2.12f1-windows-mono-1.0.1'
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
                    -logfile /opt/base/unity-build.log \
                    -customBuildPath /opt/output/build \
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
