import React from 'react';
import HostDetail from './HostDetail';
import ScrollableContainer from '../common/ScrollableContainer';
import HostsInfoPanel from '../info-panel/HostsInfoPanel';

const HostDetailPage = ({ match }) =>
  <div className="mainContainer">
    <ScrollableContainer>
      <HostDetail hostId={match.params.hostId} />
    </ScrollableContainer>
    <HostsInfoPanel hostId={match.params.hostId} />
  </div>;

HostDetailPage.propTypes = {
  match: React.PropTypes.object.isRequired
};

export default HostDetailPage;
